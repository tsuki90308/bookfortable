<template>
   
  </template>
  
  <script>
  export default {
    name: 'WorkCard',
    props: {
      work: {
        type: Object,
        required: true
      }
    }
  }
  </script>
  
  <style scoped>
    .card:hover{
      background: linear-gradient(
        45deg,
        rgba(29, 236, 197, 0.5),
        rgba(91, 14, 214, 0.5) 100%
      );
    }
    .card-body.card-img-overlay{
      opacity: 0;
    }
    .card-body.card-img-overlay:hover{
      opacity: 1;
      background: linear-gradient(
        45deg,
        rgba(29, 236, 197, 0.3),
        rgba(91, 14, 214, 0.3) 100%
      );
    }
  </style>