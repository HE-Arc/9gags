<template>
  <div>
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-brand :to="{name: 'home'}">9gags</b-navbar-brand>
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav>
          <b-nav-item :active="$store.state.utils.mode===1" @click="setModeRedirect(1)">New</b-nav-item>
          <b-nav-item :active="$store.state.utils.mode===2" @click="setModeRedirect(2)">Top</b-nav-item>


        </b-navbar-nav>

        <b-navbar-nav class="ml-auto">
          <b-nav-item @click="resetData" class="mr-2"><i class="fas fa-recycle"></i></b-nav-item>
          <b-nav-item v-b-modal.modal-create class="mr-2" ><i class="fas fa-plus"></i></b-nav-item>
          <b-nav-item class="ml-4" @click.prevent="changeLog">
            <i class="mr-1 fas fa-sign-out-alt" v-show="isLogged"></i>
            <i class="mr-1 fas fa-sign-in-alt" v-show="!isLogged"></i>
             {{textLog}}
          </b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <modal-create />
  </div>
</template>

<script>
  import ModalCreate from './ModalCreate.vue'

  export default {
    name: 'Navbar',
    components: {
      ModalCreate,
    },
    methods: {
      changeLog () {
        if(this.isLogged) {
          this.$store.dispatch('auth/logout')
          this.$router.push({name: 'index'})
        } else {
          this.$store.dispatch('auth/login')
        }
      },
      resetData() {
        this.axios.delete("https://localhost:44342/api/data").then(result => {
          if(result.data[0] === "ok") {
            this.$store.commit('utils/SETSHOULDREFRESH', true)
          }
        })
      },
      setModeRedirect(m) {
        this.$store.commit('utils/SETMODE', m)
        this.$store.commit('utils/SETSHOULDREFRESH', true)
        this.$router.push({name: 'post'})
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