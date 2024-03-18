<template>
    <div class="members-container">
      <h2 class="members-title">會員列表</h2>
      <div v-for="(member, index) in members" :key="index" class="member-item" @click="navigateToPage(index)">
        <div class="member-details">
          <h3 class="member-name">{{ member.mName }}</h3>
          <p class="member-email">{{ member.mMail }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script setup>
  import { onMounted, ref } from 'vue';
  import { useRouter } from 'vue-router'; // 引入 Vue Router 的 useRouter 函數
  
  const router = useRouter(); // 創建路由器實例
  
  const members = ref([]);
  
  const loadMembers = async () => {
    try {
      const API_URL = `${import.meta.env.VITE_API_WISHLISTURL}/members`;
      const response = await fetch(API_URL);
      const data = await response.json();
      members.value = data;
    } catch (error) {
      console.error('Error loading members:', error);
    }
  };
  
  onMounted(() => {
    loadMembers();
  });
  
  const navigateToPage = (index) => {
    const member = members.value[index];
    if (member) {
      if (index === 0) {
        // 如果點擊第一個區塊，導航到 A 網頁
        router.push('/wishlist');
      } else if (index === 1) {
        // 如果點擊第二個區塊，導航到 B 網頁
        router.push('/wishlist2');
      }
      // 可以根據需要添加更多的條件和導航路徑
    }
  };
  </script>
  
  <style scoped>
  .members-container {
    margin-top: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
  }
  
  .members-title {
    font-size: 24px;
    margin-bottom: 10px;
    text-align: center;
  }
  
  .member-item {
    width: 40%;
    margin-bottom: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
    cursor: pointer; 
  }
  
  .member-details {
    padding: 20px;
    text-align: center;
  }
  
  .member-name {
    font-size: 18px;
    margin: 0;
  }
  
  .member-email {
    font-size: 14px;
    margin: 5px 0;
  }
  </style>