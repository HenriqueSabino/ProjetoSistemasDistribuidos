from sqlalchemy import Column, DateTime, ForeignKey, Float

from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base


class Output(Base):
    __tablename__ = 'outputs'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    store_id = Column(UUID(as_uuid=True), ForeignKey('store.id'))
    shipping_company_id = Column(UUID(as_uuid=True), ForeignKey('shipping_company.id'))
    total = Column(Float)
    shipping = Column(Float)
    interest = Column(Float)
    created_at = Column(DateTime)

    store = relationship('Store')
    shipping_company = relationship('ShippingCompany')
