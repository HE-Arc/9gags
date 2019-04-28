import Vue from 'vue'
import Vuex from 'vuex'
import auth from './modules/auth'
import utils from './modules/utils'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    auth,
    utils,
  },
})
