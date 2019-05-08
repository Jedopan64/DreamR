<template>
	<div>
		<ul v-if="dreams.length">
			<Dream
				v-for="dream in dreams"
				:key="dream.id"
				:dream="dream"
			/>
		</ul>
		<p v-else>
			Nothing left in the list. Add a new dream in the input above.
		</p>
	</div>
</template>

<script>
import Dream from './Dream.vue'
let nextDreamId = 1

export default {
	components: {
		Dream
	},
  data () {
    return {
      dreams: [
			 {
        id: nextDreamId++,
        name: "Dream1",
        category: "cat1",
        img: "https://www.placecage.com/201/200",
        text: "Opis numer 1...."
      },
      {
        id: nextDreamId++,
        name: "Dream2",
        category: "cat2",
        img: "https://www.placecage.com/200/201",
        text: "Opis numer 2.."
      },
      {
        id: nextDreamId++,
        name: "Dream3",
        category: "cat3",
        img: "https://www.placecage.com/200/200",
        text: "Opis numer 3...."
      }
			]
    }
  },
}
</script>