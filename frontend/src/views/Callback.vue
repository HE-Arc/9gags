<template>
  <div>
    <h3>Loading...</h3>
  </div>
</template>

<script>
  export default {
    name: 'Callback',
    mounted () {
      this.$store.dispatch('auth/handleAuthentication')
    }
  }
</script>

<style scoped>

</style>