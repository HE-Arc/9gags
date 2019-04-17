import Vue from 'vue'
import Router from 'vue-router'
import Post from './views/Post.vue'
import Home from './views/Home.vue'
import Callback from './views/Callback'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/home',
      name: 'home',
      component: Home
    },
    {
      path: '/post',
      name: 'post',
      component: Post
    },
    {
      path: '/callback',
      name: 'callback',
      component: Callback
    }
  ]
})
