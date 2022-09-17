from sqlalchemy import Column, DateTime, Float, Integer
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship

from inventory.database import Base


class Entry(Base):
    __tablename__ = 'entries'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    shipping_company_id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    total = Column(Float)
    shipping = Column(Float)
    interest = Column(Float)
    invoice = Column(Integer)
    created_at = Column(DateTime)

    shipping_company = relationship('ShippingCompany')
