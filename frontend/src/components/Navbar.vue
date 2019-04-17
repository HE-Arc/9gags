<template>
  <div>
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-brand :to="{name: 'home'}">9gags</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item :to="{ name: 'post'}">New</b-nav-item>
          <b-nav-item :to="{ name: 'post'}">Top</b-nav-item>
          <b-nav-item :to="{ name: 'post'}">Random</b-nav-item>


        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
          <b-nav-item class="mr-2" href="/add"><i class="fas fa-plus"></i></b-nav-item>
          <b-nav-item class="ml-4" @click.prevent="changeLog">
            <i class="mr-1 fas fa-sign-out-alt" v-show="isLogged"></i>
            <i class="mr-1 fas fa-sign-in-alt" v-show="!isLogged"></i>
             {{textLog}}
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
  export default {
    name: 'Navbar',
    methods: {
      changeLog () {
        if(this.isLogged) {
          this.$store.dispatch('auth/logout')
          this.$router.push({name: 'index'})
        } else {
          this.$store.dispatch('auth/login')
        }
      }
    },
    computed: {
      isLogged () {
        return this.$store.state.auth.isLogged
      },
      textLog () {
        if(this.isLogged) {
          return'sign out'
        }
        return 'sign in'
      }
    }
  }
</script>

<style scoped>

</style>