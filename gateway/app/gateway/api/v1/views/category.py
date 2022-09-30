import json
import os
import requests

from rest_framework import status
from rest_framework.response import Response
from rest_framework.generics import GenericAPIView

from gateway.api.v1.serializers.category import CategorySerializer


class CategoryAPIView(GenericAPIView):
    serializer_class = CategorySerializer

    def get(self, request, *args, **kwargs):
        res = requests.get(f"{os.getenv('INVENTORY_API')}/api/v1/categories/")
        data = json.loads(res.content)
        serializer = self.get_serializer(data=data, many=True)
        serializer.is_valid(raise_exception=True)
        return Response(
            serializer.data,
            status=status.HTTP_200_OK
        )

    def post(self, request, *args, **kwargs):
        serializer = CategorySerializer(data=request.data)
        serializer.is_valid(raise_exception=True)
        res = requests.post(f"{os.getenv('INVENTORY_API')}/api/v1/categories/", json=serializer.data)
        if res.status_code == 201:
            return Response(
                serializer.data,
                status=status.HTTP_201_CREATED
            )
        else:
            return Response(
                status=status.HTTP_400_BAD_REQUEST
            )
