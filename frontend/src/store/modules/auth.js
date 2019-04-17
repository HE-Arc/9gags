import auth0 from 'auth0-js'
require('../../config/config')

const webAuth = new auth0.WebAuth({
  domain: 'stevenj.eu.auth0.com',
  redirectUri: global.gConfig.callbackUrl,
  clientID: 'xqxumw9CalI4F6WtzsoWBA3KrrGsswTp',
  audience: 'https://9gags-api.com',
  responseType: 'token id_token',
})

const state = {
  isLogged: false,
}

const getters = {
  logged(state) {
    return state.isLogged
  }
}

const actions = {
  handleAuthentication() {
    webAuth.parseHash((err, authResult) => {
      if(authResult && authResult.accessToken) {
        this.axios.defaults.headers.common['Authorization'] = `Bearer ${authResult.accessToken}`
        const expiresAt = JSON.stringify(authResult.expiresIn * 1000 + new Date().getTime())
        localStorage.setItem('access_token', authResult.accessToken)
        localStorage.setItem('expires_at', expiresAt)
        this.commit('SETLOGGED', true)
        //TODO refresh username in backend.
      }
    })
    this.router.replace({name: 'home'})
  },
  login() {
    webAuth.authorize()
  },
  logout() {
    localStorage.removeItem('access_token')
    localStorage.removeItem('expires_at')
    this.commit('SETLOGGED', false)
    webAuth.logout({
      returnTo: global.gConfig.baseUrl,
    })
  },
  authenticatedFromToken() {
    const expiresAt = JSON.parse(localStorage.getItem('expires_at'))
    if(new Date().getTime() < expiresAt) {
      this.commit('SETLOGGED', true)
      this.axios.setToken(localStorage.getItem('access_token'), 'Baerer')
    } else {
      this.commit('SETLOGGED', false)
    }
  }
}

const mutations = {
  SETLOGGED(state, value) {
    state.isLogged = value
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,

}