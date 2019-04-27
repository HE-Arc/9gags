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
        article: {id: 0, name: 'Default title', vote: 0, //Default article while charging real
        image_url: 'data:image/png;base64,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'},
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
          let article = result.data
          if(article.text !== null) {
            this.article=result.data
          } else {
            //TODO redirect to home + show error
          }
        })
      },
    },
  }
</script>

<style>

</style>