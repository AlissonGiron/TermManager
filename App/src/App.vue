<template>
  <layout v-if="this.$root.isLoggedIn" />
  <login v-else />
</template>
