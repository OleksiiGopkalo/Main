from django.shortcuts import render, redirect, get_object_or_404
def main(request):
    return render(request, 'recipe/main.html')
def category_detail(request, category_slug):
    return render(request, 'recipe/category_detail.html')