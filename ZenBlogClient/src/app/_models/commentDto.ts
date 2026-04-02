import { blogDto } from "./blog";
import { SubCommentDto } from "./subCommentDto";
import { UserDto } from "./userDto";

export class CommentDto{
  id;
  firstName;
  lastName;
  email;
  blogId;
  blog:blogDto;
  body;
  commentDate;
  subComments:SubCommentDto[];
}
