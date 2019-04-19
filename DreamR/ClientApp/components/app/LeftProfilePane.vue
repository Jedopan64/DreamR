<template>
  <div id="card" v-bind:class="cardStates" class="card">
    <div class="card-info">
      <div class="card-image">
        <img v-bind:src="avatar" class="card-avatar card-avatar--circle">
      </div>
      <div class="card-fields">
        <h2 class="card-name">{{fullName}}</h2>
      </div>
    </div>
    <div class="card-fields">
      <p class="card-bio">{{bio}}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      firstName: "Nicholas",
      lastName: "Cage",
      email: "nicholas.cage@theone.com",
      avatar: "http://www.placecage.com/c/300/300",
      bio:
        "Tutaj tekst użytkownika, Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam aliquam metus eu varius mollis. Curabitur ornare massa vitae nulla malesuada posuere. In eu tortor tincidunt tortor bibendum cursus. Morbi et maximus mauris, eget dictum orci. Vestibulum suscipit dolor non leo maximus tempor. In nec libero et nibh facilisis volutpat id ultrices metus. Fusce scelerisque ullamcorper erat varius consequat. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut quis quam in magna condimentum tincidunt. Sed tincidunt, neque nec suscipit aliquam, lectus tellus blandit lorem, vitae placerat felis nulla eu dui. Aliquam convallis bibendum tristique. Proin ultricies nulla sit amet massa consequat, in fringilla urna dictum. Maecenas in mauris elit. Nullam malesuada commodo mollis. Vivamus eleifend iaculis nibh, ac scelerisque ligula suscipit id. Aenean nisi nisi, pharetra sed interdum pellentesque, viverra a lorem. Nullam et nulla a ante ultricies congue.",
      isShelfOpen: false,
      isEditing: false
    };
  },
  computed: {
    fullName() {
      return this.firstName + " " + this.lastName;
    },

    methods: {}
  }
};
</script>


<style>
.card {
  background: #fff;
  border-radius: 0.3em;
  border: 0.0625em solid mix(#fff, #abbaab, 20%);
  box-shadow: 0 0 1.7em 0 rgba(#abbaab, 0.55);
  display: flex;
  flex-direction: column;
  max-width: 18em;
  position: relative;
  width: 100%;
}

.card-info {
  padding: 1.2em 1em;
  position: relative;
  text-align: center;
  width: 100%;
}

.card-image {
  margin: auto;
  max-width: ((128px/16px) * 1em);
}

.card-avatar {
  display: block;
  height: auto;
  width: 100%;
}

.card-avatar--circle {
  border-radius: 50%;
}

.card-name {
  font-size: 1.8em;
  margin-bottom: 0.2em;
}

.card-content {
  padding: 1em;
}

.card-bio {
  margin-top: 0;
  width: 100%;
}

.card-fields {
  padding: 10px;
  display: flex;
  justify-content: center;
}

html {
  box-sizing: border-box;
}
*,
*::before,
*::after {
  box-sizing: inherit;
}
.wrapper {
  align-items: center;
  display: flex;
  justify-content: center;
  height: 100vh;
  background: radial-gradient(circle, #ffffff, #abbaab);
}
</style>
