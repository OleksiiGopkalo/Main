from django.urls import path

from recipe import views

urlpatterns = [
  path('', views.main, name='main'),
]