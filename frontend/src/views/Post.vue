<template>
  <div id="app">
    <Article v-for="a in articles" :key="a.id" :article="a"/>
    <b-container v-show="outOfNew">
      <h1>You are out of new pictures, come back later or reset the views in the navbar</h1>
    </b-container>
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
        outOfNew: false, //When no more pictures can be loaded
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
        this.$forceUpdate()
        for (let i = 0; i < 5; ++i) {
          this.addArticle()
        }
      },
      addArticle () {
        this.axios.get(`https://localhost:44342/api/data/${this.$store.state.utils.mode}`).then(result => {
          let article = result.data.article
          if (article && article.title !== null) {
            this.outOfNew = false
            article['pointUser'] = result.data.pointUser
            this.articles.push(article)
          } else {
            this.outOfNew = true
          }
        })
      },
      bottomVisible () {
        const scrollY = window.scrollY
        const visible = document.documentElement.clientHeight
        const pageHeight = document.documentElement.scrollHeight
        const bottomOfPage = visible + scrollY >= pageHeight
        return bottomOfPage || pageHeight < visible
      },
    },
    computed: {
      shouldRefresh () {
        return this.$store.getters['utils/getShouldRefresh']
      },
    },
    watch: {
      bottom (bottom) {
        if (bottom) {
          this.addArticle()
        }
      },
      shouldRefresh (newValue, oldValue) {
        if (newValue === true) {
          while (this.articles.length > 0) {
            this.articles.pop()
          }
          this.getArticles()
          this.$store.commit('utils/SETSHOULDREFRESH', false)
        }
      }
    }
  }
</script>

<style>

</style>