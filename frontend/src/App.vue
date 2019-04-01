<template>
  <div id="app">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css"
          integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <Navbar/>
    <Article v-for="a in articles" :key="a.id" :article="a"/>
  </div>
</template>

<script>
  import Navbar from './components/Navbar'
  import Article from './components/Article'

  export default {
    name: 'app',
    components: {
      Navbar,
      Article,
    },
    data () {
      return {
        articles: [],
        bottom: false,
      }
    },
    mounted () {
      this.getArticles()
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
          this.articles.push({ name: `Titre ${i}`, image_url: `https://placeimg.com/300/400/${i}`, vote: i })
        }
      },
      addArticle () {
        this.articles.push({ name: `Titre `, image_url: `https://placeimg.com/300/400/any`, vote: 0 })
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
