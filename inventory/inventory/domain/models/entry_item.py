from sqlalchemy import Column, DateTime, ForeignKey, Float, Integer

from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base


class EntryItem(Base):
    __tablename__ = 'entry_items'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    entry_id = Column(UUID(as_uuid=True), ForeignKey('entry.id'))
    product_id = Column(UUID(as_uuid=True), ForeignKey('product.id'))
    quantity = Column(Integer)
    value = Column(Float)
    created_at = Column(DateTime)

    entry = relationship('Entry')
    product = relationship('Product')
