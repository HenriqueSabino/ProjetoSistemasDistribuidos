from sqlalchemy import Column, DateTime, String
from sqlalchemy.dialects.postgresql import UUID

from inventory.database import Base


class Category(Base):
    __tablename__ = 'categories'

    id = Column(UUID(as_uuid=True), primary_key=True, index=True)
    name = Column(String(length=50))
    created_at = Column(DateTime)
