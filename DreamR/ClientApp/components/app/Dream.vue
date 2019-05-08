<template>
  <li>
    <div class="dream">
      <div class="box">
        <article class="media">
          <div class="media-left">
            <figure class="image is-64x64">
              <img :src="dream.img" alt="Image">
            </figure>
          </div>
          <div class="media-content">
            <div class="content">
              <p>
                <strong>{{dream.name}}</strong> <small>{{dream.category}}</small>
                <br>
                {{dream.text}}
              </p>
            </div>
              <div class="level-left">
                <a class="level-item">
                 
                </a>
              </div>
          </div>
        </article>
      </div>
    </div> 
    
  </li>
</template>

<script>

export default {
  props: {
    dream: {
      type: Object,
      required: true
    }
  }
}
</script>
<style>
 .media{
   vertical-align:middle;
 }
img{
  width: 80px;
  height: auto;
  border-radius: 35px;
}
.dream {

  max-width: 500px;
  margin: 0 auto;
  padding-bottom: 15px;
  border: 1px solid #ccc; 
  border-radius: 10px;
  vertical-align: middle;
}
.box{
  vertical-align: middle;
}

</style>