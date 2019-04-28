<template>
  <div>
    <h1>This is a home page</h1>
    <button @click="makeReq">Request</button>
    {{msg}}
  </div>
</template>

<script>
  export default {
    name: 'Home',
    data () {
      return {
        msg: ''
      }
    },
    methods: {
      makeReq () {
        this.axios.get('https://localhost:44342/api/values').then(result => {
          this.msg = result.data
        })
      }
    }
  }
</script>
