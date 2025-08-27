// 代码生成时间: 2025-08-27 23:10:11
using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPermissionSystem
{
    // 用户权限类
    public class UserPermission
    {
        public string UserId { get; set; }
        public List<string> Permissions { get; set; }

        public UserPermission(string userId, List<string> permissions)
        {
            UserId = userId;
            Permissions = permissions;
        }
    }

    // 用户权限管理器
    public class UserPermissionManager
    {
        private Dictionary<string, UserPermission> userPermissions = new Dictionary<string, UserPermission>();

        // 添加用户权限
        public void AddUserPermission(string userId, List<string> permissions)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");
            if (permissions == null || !permissions.Any())
                throw new ArgumentException("Permissions cannot be null or empty.");

            userPermissions[userId] = new UserPermission(userId, permissions);
        }

        // 删除用户权限
        public bool RemoveUserPermission(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");

            return userPermissions.Remove(userId);
        }

        // 检查用户是否有特定权限
        public bool HasPermission(string userId, string permission)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");
            if (string.IsNullOrEmpty(permission))
                throw new ArgumentException("Permission cannot be null or empty.");

            if (userPermissions.TryGetValue(userId, out UserPermission userPermission))
            {
                return userPermission.Permissions.Contains(permission);
            }
            return false;
        }

        // 获取用户所有权限
        public List<string> GetPermissions(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.");

            if (userPermissions.TryGetValue(userId, out UserPermission userPermission))
            {
                return userPermission.Permissions;
            }
            return new List<string>();
        }
    }
}
