import { CategoryDto } from "./category";
import { CommentDto } from "./commentDto";
import { UserDto } from "./userDto";

export class blogDto{
  id;
  title;
  description;
  coverImage;
  blogImage;
  categoryId;
  category:CategoryDto;
  userId;
  createdAt;
  updatedAt;
  user: UserDto;
  comments: CommentDto[];
}
