

const state = {
  shouldRefresh: false,
  shouldRefreshSingle: false,
  mode: 1,
}

const getters = {
  getShouldRefresh(state) {
    return state.shouldRefresh
  },
  getShouldRefreshSingle(state) {
    return state.shouldRefreshSingle
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
  SETSHOULDREFRESHSINGLE(state, value) {
    state.shouldRefreshSingle = value
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