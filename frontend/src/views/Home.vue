<template>
  <div class="container">
    <h1 class="display-3 text-center mb-4">Welcome on 9gags</h1>
    <div class="row">
        <div class="col-md-3"></div>
        <div class="col-md-6 col-12 my-md-4">
          <div class="card text-white bg-light mb-3">
            <div class="card-header bg-dark text-center">View memes</div>
            <div class="card-body text-dark">
              <img src="@/assets/1.png" class="img-fluid" alt="">
              <p class="card-text">See the best memes only once !</p>
            </div>
          </div>
        </div>
    <div class="col-md-6 col-12">
      <div class="card text-white bg-light mb-3">
            <div class="card-header bg-dark text-center">Vote for the best memes</div>
            <div class="card-body text-dark text-center">
              <img src="@/assets/2.png" class="img-fluid" alt="">
              <p class="card-text text-left">Vote for your favourite memes !</p>
            </div>
          </div>
        </div>
        <div class="col-md-6 col-12">
          <div class="card text-white bg-light mb-3">
            <div class="card-header bg-dark text-center">Share your advice with other people</div>
            <div class="card-body text-dark">
              <img src="@/assets/3.png" class="img-fluid" alt="">
              <p class="card-text">Comment posts to share your advice with other people !</p>
            </div>
          </div>
        </div>
      </div>
  </div>
</template>

<script>
  export default {
    name: 'Home',
  }
</script>
