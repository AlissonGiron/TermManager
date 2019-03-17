<template>
    <div style="display: flex;">
        <button class="btnUpDown down" @click="currentValue--">-</button>
        <input class="inputUpDown" type="text" :value="currentValue">
        <button class="btnUpDown up" @click="currentValue++">+</button>
    </div>
</template>

<script>
    export default {
        name: "numeric",
        data: function() {
            return {                    
                currentValue: 0
            }
        }
    }
</script>

<style scoped>
    .inputUpDown {
        min-height: 48px;
        border: 0;
        font-size: 20px;
        box-shadow: 0px 0px 1px grey;
        margin: 2px;
        line-height: 20px;
        padding-right: 10px;
        text-align: right;
        color: grey;
    }

    .btnUpDown {
        border: 1px solid lightgrey;
        min-width: 48px;
        min-height: 48px;
        font-size: 20px;
        line-height: 20px;
        font-weight: bold;
        transition: 0.1s all linear;
        color: white;
    }

    .down {
        background-color: indianred;
    }

    .up {
        background-color: lightgreen;
    }

    .btnUpDown:hover {
        transform: scale(1.02);
        border: 0;
        cursor: pointer;
    }
</style>