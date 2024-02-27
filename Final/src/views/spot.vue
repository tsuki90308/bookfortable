<template>
    <h2>台北市景點資料</h2>
    <!-- <nav class="mt-3">
        <ul class="pagination">
            <li class="page-item" v-for="(value, index) in results.totalPages" :key="index" @click="pagingHandler(value)">
                <a :class="{ 'currentPage': terms.page === value, 'page-link': true }">{{ value }}</a>
            </li>
        </ul>
    </nav> -->
    <div class="row">
        <div class="col-3">
            <PageSize @PageSizeChange="changeHandler"></PageSize>
        </div>
        <div class="col-3">
            <paging :totalPages="results.totalPages" :thePage="terms.page" @childClick="pagingHandler"></paging>
        </div>
        <div class="col-3">
            <SpotSort @sortChange="sortChangeHandler"></SpotSort>
        </div>
        <div class="col-3">
            <SearchTextBox @searchInput="keywordHandler"></SearchTextBox>
        </div>
        <div class="col-12">
            <Categories @categoryClick="categoryClickHandler"></Categories>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4 mt-3">
        <div class="col" v-for="{ spotId, spotImage, spotTitle, spotDescription, address } in results.spots" :key="spotId">
            <div class="card h-100">
                <img :src="spotImage" class="card-img-top" :alt="spotTitle">
                <div class="card-body">
                    <h5 class="card-title">{{ spotId }} {{ spotTitle }}</h5>
                    <p class="card-text">{{ spotDescription.length <= 100 ? spotDescription : spotDescription.substring(0,
                        100) }}...</p>
                </div>
                <div class="card-footer">
                    <small class="text-body-secondary">{{ address }}</small>
                </div>
            </div>
        </div>
    </div>
</template>
        
<script setup>
import { onMounted, reactive } from "vue";
import Paging from "@/components/Paging.vue";
import SearchTextBox from "@/components/SearchTextBox.vue";
import PageSize from "@/components/PageSize.vue";
import SpotSort from "@/components/SpotSort.vue";
import Categories from "@/components/Categories.vue";

const results = reactive({
    "totalPages": 0,
    "spots": []
})
const terms = reactive({ "keyword": "", "categoryId": 0, "sortBy": "spotId", "sortType": "asc", "page": 1, "pageSize": 9 });
const loadSpots = async () => {
    const API_URL = `${import.meta.env.VITE_API_SPOTURL}/Spots`;
    const response = await fetch(API_URL, {
        method: 'POST',
        body: JSON.stringify(terms),
        headers: { 'Content-Type': 'application/json' }
    })
    const datas = await response.json();
    //console.log(datas);
    results.spots = datas.spotsResult;
    //最多八頁
    results.totalPages = datas.totalPages > 8 ? 8 : datas.totalPages;

}

// const loadCategories = async () => {
//     console.log(import.meta.env.VITE_API_SPOTURL);
//     const API_URL = `${import.meta.env.VITE_API_SPOTURL}/categories`;
//     const response = await fetch(API_URL)
//     const results = await response.json();
//     console.log(results);
// }

//分頁功能
const pagingHandler = page => {
    terms.page = page
    loadSpots()
}

//關鍵字搜尋
const keywordHandler = value => {
    terms.keyword = value
    terms.page = 1
    loadSpots()
}

//設定每頁幾筆資料
const changeHandler = value => {
    terms.pageSize = +value
    terms.page = 1
    loadSpots()
}

//排序
const sortChangeHandler = value => {
    console.log(value)
    terms.sortType = value.type
    terms.sortBy = value.by
    loadSpots()
}

//根據景點分類帶出產品資料
const categoryClickHandler = id => {
    terms.categoryId = id
    terms.page = 1
    loadSpots()
}

onMounted(() => {
    //loadCategories();
    loadSpots();
})
</script>
        
<style scoped></style>