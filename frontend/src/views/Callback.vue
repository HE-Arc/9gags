<template>
  <div>
    <h3>Loading...</h3>
  </div>
</template>

<script>
  export default {
    name: 'Callback',
    mounted () {
      this.$store.dispatch('auth/handleAuthentication', {axios: this.axios, router: this.$router})
    }
  }
</script>

<style scoped>

</style>