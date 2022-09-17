from sqlalchemy import Column, DateTime, String
from sqlalchemy.dialects.postgresql import UUID

from inventory.database import Base

class City(Base):
    __tablename__ = 'shipping_companies'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    name = Column(String(length=50))
    federative_unit = Column(String(length=2))
    created_at = Column(DateTime)
