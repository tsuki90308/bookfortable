<template>
    <nav class="navbar navbar-expand-lg bg-body-tertiary my-2">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">vue3-spots</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <router-link to="/" class="nav-link active">首頁</router-link>

                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/about">關於我們</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/contact">聯絡我們</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/spots">景點資料</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>
    
<script setup>

</script>
    
<style></style>