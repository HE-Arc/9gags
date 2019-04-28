

const state = {
  shouldRefresh: false,
}

const getters = {
  getShouldRefresh(state) {
    return state.shouldRefresh
  }
}

const actions = {
 
}

const mutations = {
  SETSHOULDREFRESH(state, value) {
    state.shouldRefresh = value
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}