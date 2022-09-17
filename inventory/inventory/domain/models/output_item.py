from sqlalchemy import Column, DateTime, ForeignKey, Float, Integer

from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base


class OutputItem(Base):
    __tablename__ = 'output_items'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    output_id = Column(UUID(as_uuid=True), ForeignKey('output.id'))
    product_id = Column(UUID(as_uuid=True), ForeignKey('product.id'))
    quantity = Column(Integer)
    value = Column(Float)
    created_at = Column(DateTime)

    output = relationship('Output')
    product = relationship('Product')
