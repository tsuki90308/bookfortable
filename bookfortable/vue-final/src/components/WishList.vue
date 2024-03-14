<template>
  <div class="container">
    <h2>我的願望清單</h2>

    <!-- 分頁按鈕 -->
    <nav aria-label="Page navigation example" class="pagination-container">
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

    <router-link to="/create" class="btn btn-primary">新增</router-link>

    <div class="col-3">
            <SearchTextBox @searchInput="keywordHandler"></SearchTextBox>
        </div>

        <div class="col-6">
  <div class="input-group">
    <input type="number" class="form-control" placeholder="最低價格" min="0" v-model="priceRange.min">
    <input type="number" class="form-control" placeholder="最高價格" min="0" v-model="priceRange.max">
    <button class="btn btn-primary" type="button" @click="priceQueryHandler">查詢</button>
    <!-- 添加一个警告提示，用于显示最低价格高于最高价格的情况 -->
    <div v-if="priceRange.min !== null && priceRange.max !== null && parseFloat(priceRange.min) > parseFloat(priceRange.max)" class="text-danger mt-1">
    最低價格不能高於最高價格
  </div>
  </div>
</div>

    <div class="row row-cols-1 row-cols-md-3 g-4">
      <!-- 如果沒有搜尋結果顯示提示消息 -->
      <div v-if="result.wishListResult.length === 0" class="col">
        <div class="no-results-message">
        <p>沒有符合搜尋條件的項目。</p>
      </div>
    </div>

      <!-- 顯示願望清單項目 -->
      <div class="col" v-for="(item, index) in result.wishListResult" :key="index">
<div class="card h-100">
  <div class="d-flex justify-content-center align-items-center" style="height: 350px;">
    <img :src="'/bookfortable/bookfortable/wwwroot/images/' + item.productImage" class="card-img-top" :alt="item.productName" style="width: 200px; height: 300px;">
  </div>
  <div class="card-body">
    <h5 class="card-title">{{ item.productName }}</h5>

        <p class="card-text">{{item.productDescribe}}</p>
      </div>
      <div class="card-footer d-flex justify-content-between align-items-center">
        <small class="text-body-secondary">{{item.creationDate}} {{item.address}}</small>
        <div>
    <span class="text-danger price">NT${{item.wishPrice}}</span>
    <button class="btn btn-sm btn-danger ml-2" @click="confirmDelete(item.wishListId)">刪除</button>
  </div>
</div>
      </div>
    </div>
  </div>
</div>

<!-- 刪除確認彈跳框 -->
<div class="modal fade" id="confirmDeleteModal" tabindex="-1" role="dialog" aria-labelledby="confirmDeleteModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="confirmDeleteModalLabel">確認刪除</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        確定要刪除此項目嗎？
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
        <button type="button" class="btn btn-danger" @click="deleteConfirmed">確定</button>
      </div>
    </div>
  </div>
</div>

  <div class="bottom-pagination-container">
    <nav aria-label="Page navigation example" class="pagination">
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
    "pageSize":9,
    "minPrice": null, 
    "maxPrice": null  
  });

  //回傳的資料
  const result = reactive({
    totalPages: 1,
    wishListResult:[]
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
    terms.wishlistId = 0;
    loadWishLists();
  }

  //關鍵字搜尋
const keywordHandler = value => {
    terms.keyword = value;
    terms.page = 1;
    terms.wishlistId = 0;
    loadWishLists();
    result.page = 1;
}

// 刪除願望清單項目
const deleteWishListItem = async (wishlistId) => {
try {
  const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/wishlists/${wishlistId}`;
  const response = await fetch(API_URL, {
    method: 'DELETE',
    headers: { 'Content-Type': 'application/json' }
  });

  if (response.ok) {
    // 成功刪除後，手動移除被刪除的項目
    result.wishListResult = result.wishListResult.filter(item => item.wishListId !== wishlistId);
  } else {
    // 如果刪除失敗，顯示錯誤消息
    console.error('刪除失敗');
  }
} catch (error) {
  console.error('發生錯誤:', error);
}
};



 // 確認刪除功能
 const confirmDelete = (wishlistId) => {
  // 設定要刪除的項目 ID
  terms.wishlistId = wishlistId;
  // 手動觸發 Bootstrap Modal 的顯示
  $('#confirmDeleteModal').modal('show');
};

// 使用者確定刪除後的處理方法
const deleteConfirmed = async () => {
  // 隱藏 Bootstrap Modal
  $('#confirmDeleteModal').modal('hide');
  // 執行刪除操作
  await deleteWishListItem(terms.wishlistId);
};

const priceRange = reactive({
min: null,
max: null
});

// 價格查詢處理器
const priceQueryHandler = () => {
// 確保最低價格和最高價格都有值，並且都是有效的數字
if (priceRange.min !== null && priceRange.max !== null && !isNaN(priceRange.min) && !isNaN(priceRange.max)) {
  // 確保最低價格小於等於最高價格
  if (parseFloat(priceRange.min) <= parseFloat(priceRange.max)) {
    // 使用完整的願望清單資料來進行價格篩選
    const filteredWishList = result.wishListResult.filter(item => {
      return item.wishPrice >= parseFloat(priceRange.min) && item.wishPrice <= parseFloat(priceRange.max);
    });
    // 更新顯示的願望清單資料
    result.wishListResult = filteredWishList;
  } else {
    // 最低價格高於最高價格時，顯示警告信息
    console.error('最低價格不能大於最高價格');
  }
} else {
  console.error('請輸入有效的價格範圍');
}
};



  onMounted(() => {
    result.page = 1;
    loadWishLists();
  });


</script>
  
<style scoped>
  h2{
    text-align: center;
    margin: 0 auto;
    max-width: 600px;
    padding: 20px;
    font-size: 60px;
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
  .container {
    padding-bottom: 50px;
  }
  .price {
  color: #dc3545; /* 深紅色 */
  font-size: larger; /* 或者根據需要調整字體大小 */
  margin-right: 8px; /* 添加右邊距 */
}
/* 分頁按鈕置中 */
  .pagination-container,
  .bottom-pagination-container {
    display: flex;
    justify-content: center;
    margin-top: 20px; /* 距離上方內容的距離 */
  }

</style>