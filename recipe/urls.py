from django.urls import path

from recipe import views

urlpatterns = [
  path('', views.main, name='main'),
  path('category_detail/', views.category_detail, name='category_detail'),
]