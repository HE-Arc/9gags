

const state = {
  shouldRefresh: false,
  mode: 1,
}

const getters = {
  getShouldRefresh(state) {
    return state.shouldRefresh
  },
  getMode(state){
    return state.mode
  }
}

const actions = {
 
}

const mutations = {
  SETSHOULDREFRESH(state, value) {
    state.shouldRefresh = value
  },
  SETMODE(state, value) {
    state.mode = value
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}