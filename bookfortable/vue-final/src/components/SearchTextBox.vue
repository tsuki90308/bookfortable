<template>
  <input type="search" @input="inputHandler" v-model="keyword" placeholder="關鍵字搜尋" class="form-control mb-3"> 
</template>

<script setup>
import { ref } from 'vue'
const keyword = ref("")
const emit = defineEmits(["searchInput"])
const inputHandler = () => {
    emit("searchInput", keyword.value)
}
</script>

<style>

</style>