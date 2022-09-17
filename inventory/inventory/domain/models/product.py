from sqlalchemy import Column, DateTime, ForeignKey, String
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base

class Product(Base):
    __tablename__ = 'products'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    category_id = Column(UUID(as_uuid=True), ForeignKey('category.id'))
    provider_id = Column(UUID(as_uuid=True), ForeignKey('provider.id'))
    description = Column(String(length=400))
    created_at = Column(DateTime)

    category = relationship('Category')
    provider = relationship('Provider')
