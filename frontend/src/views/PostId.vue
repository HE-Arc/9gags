<template>
  <div id="app">
    <Article :article="article"/>
  </div>
</template>

<script>
  import Article from '../components/Article'

  export default {
    name: 'PostId',
    components: {
      Article,
    },
    data () {
      return {
        article: {
          id: 0,
          pointUser: 0,
          name: 'Default title',
          vote: 0,
          path: 'https://image.shutterstock.com/image-vector/download-sign-load-icon-system-260nw-425121802.jpg'
        }, //Default article while charging real
      }
    },
    mounted () {
      this.$nextTick(() => {
        if (this.$store.state.auth.isLogged === true) {
          this.getArticle()
        } else {
          this.$store.watch(() => this.$store.getters['auth/logged'], () => {
            this.getArticle() //Wait, while checking if session is logged
          })
          setTimeout(() => { //If we aren't logged after 1s redirect to login
            if (this.$store.state.auth.isLogged === false) {
              this.$store.dispatch('auth/login')
            }
          }, 1000)
        }
      })
    },
    methods: {
      getArticle () {
        //TODO Get article id
        this.axios.get(`https://localhost:44342/api/image/${this.$route.params.id}`).then(result => {
          let article = result.data.article
          let pointUser = result.data.pointUser
          if (article && article.text !== null) {
            article['pointUser'] = pointUser
            this.article = article
          } else {
            this.$router.push({name: 'home'})
          }
        })
      },
    },
    computed:{
      shouldRefreshSingle() {
        return this.$store.getters['utils/getShouldRefreshSingle']
      },
    },
     watch: {
      shouldRefreshSingle(newValue, oldValue) {
        if(newValue===true) {
          this.getArticle()
          this.$store.commit('utils/SETSHOULDREFRESHSINGLE', false)
        }
      }
    }
  }
</script>

<style>

</style>