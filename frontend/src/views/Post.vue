<template>
  <div id="app">
    <Article v-for="a in articles" :key="a.id" :article="a"/>
  </div>
</template>

<script>
  import Article from '../components/Article'

  export default {
    name: 'Post',
    components: {
      Article,
    },
    data () {
      return {
        articles: [],
        bottom: false,
      }
    },
    mounted () {
      this.$nextTick(() => {
        if (this.$store.state.auth.isLogged === true) {
          this.getArticles()
        } else {
          this.$store.watch(() => this.$store.getters['auth/logged'], () => {
            this.getArticles() //Wait, while checking if session is logged
          })
          setTimeout(() => { //If we aren't logged after 1s redirect to login
            if (this.$store.state.auth.isLogged === false) {
              this.$store.dispatch('auth/login')
            }
          }, 1000)
        }
      })

    },
    created () {
      window.addEventListener('scroll', () => {this.bottom = this.bottomVisible()})
    },
    destroyed () {
      window.removeEventListener('scroll', () => {this.bottom = this.bottomVisible()})
    },
    methods: {
      getArticles () {
        //Request articles
        for (let i = 0; i < 5; i++) {
          this.articles.push({ id: i, name: `Titre ${i}`, image_url: `https://placeimg.com/300/400/${i}`, vote: i })
        }
      },
      addArticle () {
        this.articles.push({ id: -1, name: `Titre `, image_url: `https://placeimg.com/300/400/any`, vote: 0 })
      },
      bottomVisible () {
        const scrollY = window.scrollY
        const visible = document.documentElement.clientHeight
        const pageHeight = document.documentElement.scrollHeight
        const bottomOfPage = visible + scrollY >= pageHeight
        return bottomOfPage || pageHeight < visible
      },
    },
    watch: {
      bottom (bottom) {
        if (bottom) {
          this.addArticle()
        }
      }
    }
  }
</script>

<style>

</style>