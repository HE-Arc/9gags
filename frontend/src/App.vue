<template>
  <div id="app">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css"
          integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <Navbar/>
    <router-view/>
  </div>
</template>

<script>
  import Navbar from './components/Navbar'

  export default {
    name: 'app',
    components: {
      Navbar,
    },
    mounted() {
      this.$nextTick(() => {
      this.$store.dispatch('auth/authenticatedFromToken', {axios: this.axios, router: this.$router})
      })
    },
  }
</script>

<style>

</style>
