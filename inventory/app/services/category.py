from nameko.rpc import rpc

from inventory.serializers import category

class CategoryService:
    name = 'categories'

    @rpc
    def create_order(self, data):
        serializer = category.Category(data=data)
        serializer.is_valid(raise_exception=True)

        serializer.save()

        return serializer.data
