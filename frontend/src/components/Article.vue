<template>
  <b-container class="my-3">
    <b-card-group deck>
      <b-card border-variant="dark" :header="article.name" align="center">
        <b-card-body>
          <b-img ref="imgArticle" :src="article.image_url" fluid alt="" @load="calcMarginButton"/>
          <div class="float-left" ref="buttonArticle" :style="{marginTop: marginImgArticle + 'px'}">
            <div class="col">
              <div class="row">
                <b-button @click="actualVote=1" :style="{color: actualVote===1 ? '#25DD25' : 'white'}"><i class="fas fa-chevron-up"></i></b-button>
              </div>
              <div class="row justify-content-md-center my-2" :style="{color: voteColor}">
                  {{vote}}
              </div>
              <div class="row">
                <b-button @click="actualVote=-1"  :style="{color: actualVote===-1 ? '#FF0000' : 'white'}"><i class="fas fa-chevron-down"></i></b-button>
              </div>
            </div>
          </div>
          <br>
          <b-button class="my-3" @click="showComment= !showComment">{{showComment ? 'Hide comment' : 'Show comment'}}</b-button>

          <div v-show="showComment" class="row border border-secondary rounded px-2">
            <div class="col-12 my-1 text-left border border-secondary rounded" v-for="i in 10">
              <small class="my-0">Title</small>
              <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet esse tempora cupiditate porro aspernatur veniam deserunt, adipisci unde asperiores impedit a nam quasi et, odio vitae? Deleniti et dolorum aliquid!</p>
            </div>
          </div>
        </b-card-body>
      </b-card>
    </b-card-group>
  </b-container>
</template>

<script>
  export default {
    name: 'Article',
    props: {
      article: Object,
    },
    data () {
      return {
        marginImgArticle: 50,
        vote: 0,
        actualVote: 0,
        showComment: false,
      }
    },
    mounted () {
      this.vote = this.article.vote
      this.loaded = true
    },
    methods: {
      calcMarginButton() {
        this.marginImgArticle = this.$refs.imgArticle.height / 2 - this.$refs.buttonArticle.clientHeight / 2
      },
    },
    computed: {
      voteColor() {
        if(this.vote < 0) {
          return '#FF0000'
        } if(this.vote > 0) {
         return '#25DD25'
        }
        return '#000'
      },
    },
    watch: {
      actualVote(newValue, oldValue) {
        this.vote -= oldValue
        this.vote += newValue
      },
    }
  }
</script>

<style scoped>

</style>