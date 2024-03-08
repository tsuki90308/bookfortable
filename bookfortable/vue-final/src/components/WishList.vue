<template>
  <div class="container">
    <h2>我的願望清單</h2>
    <nav aria-label="Page navigation example">
      <ul class="pagination">
        <li class="page-item">
          <a class="page-link" href="#" aria-label="First" @click="pagingHanler(1)">
            <span aria-hidden="true">&lt;&lt;</span>
          </a>
        </li>
        <li class="page-item" v-for="(value,index) in result.totalPages" :key="index" :class="{ 'active': value === result.page }" @click="pagingHanler(value)">
          <a class="page-link" href="#">{{value}}</a>
        </li>
        <li class="page-item">
          <a class="page-link" href="#" aria-label="Last" @click="pagingHanler(result.totalPages)">
            <span aria-hidden="true">&gt;&gt;</span>
          </a>
        </li>
      </ul>
    </nav>

    <div class="col-3">
            <SearchTextBox @searchInput="keywordHandler"></SearchTextBox>
        </div>

    <div class="row row-cols-1 row-cols-md-3 g-4">
      <!-- 如果沒有搜尋結果顯示提示消息 -->
      <div v-if="result.wishListResult.length === 0" class="col">
        <div class="no-results-message">
        <p>沒有符合搜尋條件的項目。</p>
      </div>
    </div>
       <!-- 顯示願望清單項目 -->
  <div class="col" v-for="{wishlistId,productName,address,creationDate,
productDescribe,productImage} in result.wishListResult" :key="wishlistId">
    <div class="card h-100">
      <div class="d-flex justify-content-center align-items-center" style="height: 350px;">
      <img :src="'/src/img/' + productImage" class="card-img-top" :alt="productName" style="width: 200px; height: 300px;">
    </div>
      <div class="card-body">
        <h5 class="card-title">{{wishlistId}} {{productName}}</h5>
        <p class="card-text">{{productDescribe}}</p>
      </div>
      <div class="card-footer">
        <small class="text-body-secondary">{{creationDate}} {{address}}</small>
      </div>
    </div>
  </div>
</div>
</div>

</template>
   
<script setup>
   import { onMounted , reactive} from 'vue';
   import SearchTextBox from "@/components/SearchTextBox.vue";
   //搜尋.分頁.排序的條件
   const terms = reactive({
    "keyword":"",
    "wishlistId":0,
    "sortBy":"wishlistId",
    "sortType":"asc",
    "page":1,
    "pageSize":9
   });

   //回傳的資料
   const result = reactive({
    "totalPages": 1,
    "wishListResult":[]
   });
   //呼叫API
   const loadWishLists = async () => {
    const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/wishlists`;
    const response = await fetch(API_URL,{
      method:'POST',
      body:JSON.stringify(terms),
      headers : { 'Content-Type':'application/json'}
    });
    const datas = await response.json();
    result.totalPages = datas.totalPages > 8 ? 8 : datas.totalPages;
    result.wishListResult = datas.wishListResult;
   

   // 如果沒有搜尋結果，清空願望清單資料
  if (result.wishListResult.length === 0) {
    result.totalPages = 1;
    result.wishListResult = [];
  }
};


   //分頁
  const pagingHanler = page => {
    terms.page = page;
    result.page = page; // 更新當前頁碼
    loadWishLists();
  }

  //關鍵字搜尋
const keywordHandler = value => {
    terms.keyword = value;
    terms.page = 1;
    loadWishLists();
}



  //  const loadWishLists = async () => {
  //   //console.log(import.meta.env.VITE_API_WISHLISTURL);

  //   //const API_URL = "https://localhost:7080/api/WishLists";
  //   const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/wishlists`;
  //   const response = await fetch(API_URL)
  //   const datas = await response.json();
  //   console.log(datas);
  //  }

  onMounted(() => {
    result.page = 1;
    loadWishLists();
  });

</script>
   
<style scoped>
   h2{
    text-align: left;
    margin: 0 auto;
    max-width: 600px;
    padding: 20px;
   }
   /* 當前頁碼的背景色 */
  .pagination .page-item.active .page-link {
    background-color: #007bff;
    border-color: #007bff;
    color: #fff; /* 設定文字顏色為白色 */
  }
  .no-results-message {
    color: red;
    font-weight: bold;
    font-size: 20px;
  }
</style>