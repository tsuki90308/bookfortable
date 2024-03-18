<template>
    <div class="container">
      <h2 style="margin-bottom: 20px;">新增願望清單項目</h2>
  
      <!-- 願望清單表單 -->
      <form @submit.prevent="submitForm">
        <div class="form-group">
          <label for="productName" style="font-weight: bold;">產品名稱</label>
          <input type="text" class="form-control" v-model="searchTerm" @input="searchProducts" placeholder="輸入產品名稱">
          <div v-if="showResults" class="search-results">
            <div v-for="product in filteredProducts" :key="product.productName" @click="selectProduct(product)" class="search-item">
              {{ product.productName }}
            </div>
          </div>
          <p v-if="filteredProducts.length === 0 && searchTerm.length > 0" class="text-danger" style="margin-top: 5px;">沒有查詢結果</p>
        </div>
        
        <div class="form-group">
          <label for="productDescription" style="font-weight: bold;">產品描述</label>
          <textarea class="form-control" rows="3" v-model="selectedProductDescription" readonly placeholder="選擇產品後顯示描述"></textarea>
        </div>
        
        <div class="form-group">
          <label for="productPrice" style="font-weight: bold;">願望價格</label>
          <input type="number" class="form-control" v-model="wishPrice" placeholder="輸入願望價格">
        </div>
  
        <button type="submit" class="btn btn-primary" :disabled="!isValidProductName" style="margin-top: 10px;">提交</button>
      </form>
    </div>
  </template>
  
  
  <script setup>
  import { ref, onMounted } from 'vue';
  
  const searchTerm = ref('');
  const selectedProduct = ref(null); // 用于存储当前选中的产品对象
  const products = ref([]);
  const filteredProducts = ref([]);
  const isValidProductName = ref(false); // 标志位，用于验证所选产品名称是否有效
  const showResults = ref(false); // 标志位，用于控制搜索结果的显示
  const selectedProductDescription = ref(''); // 用于存储选中产品的描述
  const wishPrice = ref(''); // 新增的願望價格
  
  //呼叫API
  const loadProducts = async () => {
    try {
      const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/products`;
      const response = await fetch(API_URL);
      const data = await response.json();
      products.value = data;
      filteredProducts.value = data; // 更新 filteredProducts 的值
  
    } catch (error) {
      console.error('發生錯誤:', error);
    }
  };
  
  // 搜索產品
  const searchProducts = () => {
    filteredProducts.value = products.value.filter(product =>
      product.productName && searchTerm.value ? 
      product.productName.toLowerCase().includes(searchTerm.value.toLowerCase()) : false
    );
  
    // 根据搜索结果是否为空控制搜索结果的显示
    showResults.value = filteredProducts.value.length > 0;
  
    // 如果当前选中的产品名称不在搜索结果中，则将其重置为空
    if (!filteredProducts.value.some(product => product.productName === (selectedProduct.value ? selectedProduct.value.productName : ''))) {
      selectedProduct.value = null;
      isValidProductName.value = false;
      selectedProductDescription.value = ''; // 清空产品描述
    }
  };
  
  // 选择产品
  const selectProduct = (product) => {
    selectedProduct.value = product;
    searchTerm.value = product.productName; // 设置搜索框的值为选中产品的名称
    isValidProductName.value = true;
    showResults.value = false; // 选择产品后隐藏搜索结果
    // 更新选中产品的描述
    if (product) {
      selectedProductDescription.value = product.description; // 更新产品描述
    }
  };
  
  const submitForm = async () => {
    try {
      const data = {
        productName: selectedProduct.value.productName,
        productDescription: selectedProductDescription.value,
        wishPrice: wishPrice.value
      };
  
      const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/wishlists`;
      const response = await fetch(API_URL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
      });
  
      if (response.ok) {
        // 如果请求成功，可以执行一些操作，比如清空表单等
        console.log('WishList item added successfully!');
      } else {
        console.error('Failed to add WishList item');
      }
    } catch (error) {
      console.error('An error occurred:', error);
    }
  };
  
  
  
  onMounted(() => {
    loadProducts();
  });
  
  </script>
  
  
  <style scoped>
  .container {
    max-width: 600px; /* 设置容器最大宽度 */
    margin: 0 auto; /* 居中显示 */
  }
  
  .form-group {
    margin-bottom: 20px; /* 调整表单组件之间的间距 */
  }
  
  .search-results {
    position: absolute;
    background-color: white;
    border: 1px solid #ccc;
    max-height: 200px;
    overflow-y: auto;
  }
  
  .search-item {
    padding: 8px 12px;
    cursor: pointer;
  }
  
  .search-item:hover {
    background-color: #f0f0f0;
  }
  </style>
  