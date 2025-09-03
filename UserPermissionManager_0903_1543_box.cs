// 代码生成时间: 2025-09-03 15:43:39
using System;
using System.Collections.Generic;
using Xamarin.Forms;

// 用户权限管理系统
public class UserPermissionManager
{
    // 用户权限字典，键为用户ID，值为用户权限列表
    private Dictionary<string, List<string>> userPermissions = new Dictionary<string, List<string>>();

    // 构造器，初始化用户权限数据
    public UserPermissionManager(Dictionary<string, List<string>> initialPermissions)
    {
        if (initialPermissions == null)
            throw new ArgumentNullException(nameof(initialPermissions));

        userPermissions = new Dictionary<string, List<string>>(initialPermissions);
    }

    // 添加用户权限
    public void AddUserPermission(string userId, string permission)
    {
        if (string.IsNullOrEmpty(userId))
            throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

        if (string.IsNullOrEmpty(permission))
            throw new ArgumentException("Permission cannot be null or empty.", nameof(permission));

        if (userPermissions.ContainsKey(userId))
        {
            if (!userPermissions[userId].Contains(permission))
            {
                userPermissions[userId].Add(permission);
            }
        }
        else
        {
            userPermissions[userId] = new List<string> { permission };
        }
    }

    // 删除用户权限
    public void RemoveUserPermission(string userId, string permission)
    {
        if (userPermissions.ContainsKey(userId) && userPermissions[userId].Contains(permission))
        {
            userPermissions[userId].Remove(permission);
        }
    }

    // 检查用户是否有特定权限
    public bool HasPermission(string userId, string permission)
    {
        if (userPermissions.ContainsKey(userId))
        {
            return userPermissions[userId].Contains(permission);
        }
        return false;
    }

    // 获取用户所有权限
    public List<string> GetUserPermissions(string userId)
    {
        if (userPermissions.ContainsKey(userId))
        {
            return new List<string>(userPermissions[userId]);
        }
        return new List<string>();
    }
}
