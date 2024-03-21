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
        <label for="productPublisher" style="font-weight: bold;">出版社</label>
        <input type="text" class="form-control" v-model="selectedProductPublisher" readonly placeholder="選擇產品後顯示出版社">
      </div>
      
      <div class="form-group">
        <label for="productPrice" style="font-weight: bold;">願望價格</label>
        <input type="number" class="form-control" v-model="wishPrice" placeholder="輸入願望價格">
      </div>

      <div class="form-group">
      <label for="address" style="font-weight: bold;">地區</label>
      <input type="text" class="form-control" v-model="address" placeholder="輸入地區">
      </div>

      <div class="form-group">
        <label for="notes" style="font-weight: bold;">備註</label>
        <textarea class="form-control" rows="3" v-model="notes" placeholder="輸入備註"></textarea>
      </div>

      <button type="submit" class="btn btn-primary" :disabled="!isValidProductName" style="margin-top: 10px;">提交</button>
    </form>
    <!-- 提交成功消息 -->
    <p v-if="showSuccessMessage" class="text-success" style="margin-top: 10px;">新增成功！</p>
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
const selectedProductPublisher = ref('');
const wishPrice = ref(''); // 新增的願望價格
const showSuccessMessage = ref(false); // 标志位，用于控制提交成功消息的显示
const notes = ref('');
const address = ref('');


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
    selectedProductDescription.value = '';
    selectedProductPublisher.value = '';
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
    selectedProductPublisher.value = product.supplierId; // 更新供应商ID
  }
};

const submitForm = async () => {
  try {
    // 检查是否有选中产品以及是否输入了願望價格
    if (!selectedProduct.value || !wishPrice.value || !address.value) {
    window.alert('請填寫完整表單!!'); // 警示框提示用户填写完整的表单
    return;
    }

    const data = {
      productName: selectedProduct.value.productName,
      productDescription: selectedProductDescription.value,
      wishPrice: parseFloat(wishPrice.value),
      remark: notes.value,
      address: address.value
    };

    const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/wishlists`;
    const response = await fetch(API_URL, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(data)
    });

    if (response.ok) {
      console.log('WishList item added successfully!');
      selectedProduct.value = null;
      searchTerm.value = '';
      wishPrice.value = '';
      selectedProductDescription.value = '';
      selectedProductPublisher.value = ''; 
      notes.value = '';
      address.value = '';
      showSuccessMessage.value = true;
      setTimeout(() => {
        showSuccessMessage.value = false;
      }, 3000);
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
  margin: 70px auto; /* 居中显示 */
}

h2 {
  margin-bottom: 30px; /* 增加标题底部边距 */
}

.form-group {
  margin-bottom: 30px; /* 调整表单组件之间的间距 */
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