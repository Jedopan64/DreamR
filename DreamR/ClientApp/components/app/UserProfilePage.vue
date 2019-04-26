<template>
  <b-container>
    <b-row class="layout_row">
      <b-col class="left_pane" cols="3">
        <left-profile-pane></left-profile-pane>
      </b-col>
      <b-col class="main_pane">
        <h1>{{username}}</h1>
        <hr>
        <h2>Zrealizowane/niezrealizowane</h2>
        <hr>
        <goal-list></goal-list>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import GoalList from "./GoalList.vue";
import axios from "axios";
import LeftProfilePane from "./LeftProfilePane.vue";
export default {
  name: "profile",
  components: {
    LeftProfilePane,
    GoalList
  },
  data() {
    return {
      dreams: null
    };
  },
  computed: {
    username() {
      return `${this.$store.state.auth.email}`;
    }
  },

  methods: {
    setDreams(dreams) {
      this.dreams = dreams;
    }
  },
  beforeRouteEnter(to, from, next) {
    const vm = this;
    axios.get("/api/dreams").then(response => {
      next(vm => vm.setData(response.data));
    });
  }
};
</script>

