# recipe/tests.py

from django.test import TestCase, Client
from django.urls import reverse
from models import Recipe, Category

class RecipeViewsTestCase(TestCase):
    def setUp(self):
        self.client = Client()
        self.category = Category.objects.create(name='Desserts')
        for i in range(15):
            Recipe.objects.create(title=f'Recipe {i}', description='Description of recipe', category=self.category)

    def test_main_view(self):
        response = self.client.get(reverse('recipe:main'))
        self.assertEqual(response.status_code, 200)
        self.assertTemplateUsed(response, 'main.html')
        self.assertTrue('recipes' in response.context)
        self.assertEqual(len(response.context['recipes']), 10) 

    def test_category_detail_view(self):
        response = self.client.get(reverse('recipe:category_detail', args=[self.category.id]))
        self.assertEqual(response.status_code, 200)
        self.assertTemplateUsed(response, 'category_detail.html')
        self.assertTrue('recipes' in response.context)
        self.assertTrue('category' in response.context)
        self.assertEqual(response.context['category'], self.category)
