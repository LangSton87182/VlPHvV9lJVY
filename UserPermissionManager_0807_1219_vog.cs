// 代码生成时间: 2025-08-07 12:19:26
using System;
using System.Collections.Generic;
using System.Linq;

// 用户权限管理系统
namespace UserPermissionSystem
{
    // 定义权限枚举
    public enum Permission {
        Read,
        Write,
        Edit,
        Delete
    }

    // 用户类
    public class User
    {
        public string Username { get; set; }
        public List<Permission> Permissions { get; set; } = new List<Permission>();

        public User(string username)
        {
            Username = username;
        }

        // 添加权限
        public void AddPermission(Permission permission)
        {
            if (!Permissions.Contains(permission))
            {
                Permissions.Add(permission);
            }
        }

        // 移除权限
        public void RemovePermission(Permission permission)
        {
            Permissions.Remove(permission);
        }

        // 检查用户是否有特定权限
        public bool HasPermission(Permission permission)
        {
            return Permissions.Contains(permission);
        }
    }

    // 用户权限管理类
    public class UserPermissionManager
    {
        private List<User> users = new List<User>();

        // 添加用户
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            users.Add(user);
        }

        // 删除用户
        public void RemoveUser(string username)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                users.Remove(user);
            }
            else
            {
                throw new InvalidOperationException("User not found");
            }
        }

        // 给用户添加权限
        public void AddPermissionToUser(string username, Permission permission)
        {
            var user = GetUser(username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.AddPermission(permission);
        }

        // 从用户移除权限
        public void RemovePermissionFromUser(string username, Permission permission)
        {
            var user = GetUser(username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            user.RemovePermission(permission);
        }

        // 检查用户是否有特定权限
        public bool HasUserPermission(string username, Permission permission)
        {
            var user = GetUser(username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found");
            }

            return user.HasPermission(permission);
        }

        // 获取用户
        private User GetUser(string username)
        {
            return users.FirstOrDefault(u => u.Username == username);
        }
    }
}
