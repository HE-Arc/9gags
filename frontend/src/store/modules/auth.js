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
  handleAuthentication({}, payload) {
    webAuth.parseHash((err, authResult) => {
      if(authResult && authResult.accessToken) {
        payload.axios.defaults.headers.common['Authorization'] = `Bearer ${authResult.accessToken}`
        const expiresAt = JSON.stringify(authResult.expiresIn * 1000 + new Date().getTime())
        localStorage.setItem('access_token', authResult.accessToken)
        localStorage.setItem('expires_at', expiresAt)
        this.commit('auth/SETLOGGED', true)
        //TODO refresh username in backend.
        payload.router.push({name: 'home'})
      }
    })
  },
  login() {
    webAuth.authorize()
  },
  logout() {
    localStorage.removeItem('access_token')
    localStorage.removeItem('expires_at')
    this.commit('auth/SETLOGGED', false)
    webAuth.logout({
      returnTo: global.gConfig.baseUrl,
    })
  },
  authenticatedFromToken({}, payload) {
    const expiresAt = JSON.parse(localStorage.getItem('expires_at'))
    if(new Date().getTime() < expiresAt) {
      this.commit('auth/SETLOGGED', true)
      payload.axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem('access_token')}`
    } else {
      this.commit('auth/SETLOGGED', false)
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