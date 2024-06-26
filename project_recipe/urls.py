from django.contrib import admin
from django.urls import path, include

from recipe import views

app_name = 'recipe'

urlpatterns = [
    path('admin/', admin.site.urls),
    path('', views.main, name='main'),
    path('category_detail/', views.category_detail, name='category_detail'),
]