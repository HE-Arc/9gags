<template>
  <div id="app">
    <Navbar />
    <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
  </div>
</template>

<script>
import Navbar from './components/includes/Navbar'

export default {
  name: 'app',
  components: {
    Navbar,
  }
}
</script>

<style>

</style>
