# 🌐 网站发布指南

本文档说明如何将 OpenClaw 介绍网站发布到互联网上。

---

## 📋 准备工作

### 1. 提交当前更改

```bash
cd C:\Users\Administrator\.openclaw\workspace

# 添加所有 HTML 文件
git add about.html openclaw-intro.html privacy-policy.html

# 提交
git commit -m "feat: 添加 OpenClaw 介绍网站页面（2026.4.2 更新）"
```

### 2. 创建 GitHub 仓库（如未创建）

1. 访问 [github.com/new](https://github.com/new)
2. 仓库名称：例如 `openclaw-website` 或 `openclaw-intro`
3. 设为 **Public**（公开）
4. **不要** 初始化 README（因为本地已有代码）
5. 点击「Create repository」

### 3. 关联远程仓库

```bash
# 添加远程仓库（替换为你的仓库地址）
git remote add origin https://github.com/你的用户名/openclaw-website.git

# 推送到 GitHub
git push -u origin master
```

---

## 🚀 发布方案对比

| 方案 | 难度 | 成本 | 自定义域名 | 适合场景 |
|------|------|------|------------|----------|
| **GitHub Pages** | ⭐ 简单 | 免费 | ✅ 支持 | 静态网站、文档、项目主页 |
| **Vercel** | ⭐⭐ 中等 | 免费 | ✅ 支持 | 现代网站、自动部署 |
| **Netlify** | ⭐⭐ 中等 | 免费 | ✅ 支持 | 静态网站、表单功能 |
| **Cloudflare Pages** | ⭐⭐ 中等 | 免费 | ✅ 支持 | 全球 CDN、速度快 |
| **自有服务器** | ⭐⭐⭐⭐ 复杂 | 付费 | ✅ 支持 | 完全控制、企业级 |

---

## 方案一：GitHub Pages（推荐 ⭐）

### 优势
- ✅ 完全免费
- ✅ 与 GitHub 深度集成
- ✅ 自动 HTTPS
- ✅ 支持自定义域名
- ✅ 适合静态网站

### 发布步骤

#### 步骤 1：推送到 GitHub

```bash
cd C:\Users\Administrator\.openclaw\workspace

# 确保所有文件已提交
git add .
git commit -m "chore: 准备发布网站"

# 推送到 GitHub
git push -u origin master
```

#### 步骤 2：启用 GitHub Pages

1. 打开你的 GitHub 仓库页面
2. 点击 **Settings**（设置）
3. 左侧菜单选择 **Pages**
4. **Source** 选择：
   - Deploy from a branch
   - Branch: `master` / Folder: `/ (root)`
5. 点击 **Save**

#### 步骤 3：等待部署

- GitHub 会在 1-3 分钟内完成部署
- 页面顶部会显示访问地址，格式：
  ```
  https://你的用户名.github.io/仓库名/
  ```

#### 步骤 4：访问网站

部署完成后，访问：
```
https://你的用户名.github.io/仓库名/openclaw-intro.html
```

### 🔧 可选：配置自定义域名

1. 在 Pages 设置页面，找到 **Custom domain**
2. 输入你的域名：`openclaw.ai` 或 `www.openclaw.ai`
3. 点击 **Save**
4. 在你的域名提供商处添加 DNS 记录：
   ```
   类型：CNAME
   主机：www
   值：你的用户名.github.io
   ```

---

## 方案二：Vercel（自动化部署）

### 优势
- ✅ 自动从 GitHub 部署
- ✅ 全球 CDN
- ✅ 免费 HTTPS
- ✅ 预览部署

### 发布步骤

#### 步骤 1：注册 Vercel

1. 访问 [vercel.com](https://vercel.com)
2. 使用 GitHub 账号登录

#### 步骤 2：导入项目

1. 点击 **Add New Project**
2. 选择 **Import Git Repository**
3. 选择你的仓库 `openclaw-website`
4. 点击 **Import**

#### 步骤 3：配置部署

- **Framework Preset**: Other
- **Build Command**: 留空（静态网站无需构建）
- **Output Directory**: 留空（默认为根目录）

#### 步骤 4：部署

点击 **Deploy**，等待完成后会获得访问地址：
```
https://openclaw-website.vercel.app
```

---

## 方案三：Netlify

### 发布步骤

#### 步骤 1：注册 Netlify

1. 访问 [netlify.com](https://netlify.com)
2. 使用 GitHub 账号登录

#### 步骤 2：添加站点

1. 点击 **Add new site** → **Import an existing project**
2. 选择 **GitHub**
3. 选择你的仓库

#### 步骤 3：配置

- **Build command**: 留空
- **Publish directory**: 留空

#### 步骤 4：部署

点击 **Deploy site**，获得访问地址：
```
https://你的站点名称.netlify.app
```

---

## 方案四：Cloudflare Pages

### 发布步骤

#### 步骤 1：登录 Cloudflare

1. 访问 [pages.cloudflare.com](https://pages.cloudflare.com)
2. 使用 GitHub 账号登录

#### 步骤 2：创建项目

1. 点击 **Create a project**
2. 选择 **Connect to Git**
3. 选择你的仓库

#### 步骤 3：配置

- **Build command**: 留空
- **Build output directory**: 留空

#### 步骤 4：部署

点击 **Save and Deploy**，获得访问地址：
```
https://你的项目名称.pages.dev
```

---

## 📝 发布前检查清单

### 内容检查
- [ ] 所有链接正确（页面间互连）
- [ ] 更新日期已刷新
- [ ] 无占位符内容（如 AdSense 代码已注释）
- [ ] 标题和描述符合 SEO

### 技术检查
- [ ] HTML 语法正确
- [ ] 图片路径正确（如有）
- [ ] 响应式设计正常（移动端适配）
- [ ] 浏览器兼容性测试

### Git 检查
- [ ] 所有文件已提交
- [ ] 无敏感信息（API Key、密码等）
- [ ] .gitignore 配置正确

---

## 🔒 .gitignore 建议

创建或更新 `.gitignore` 文件，排除敏感内容：

```gitignore
# 敏感配置
*.env
openclaw.json
auth-profiles.json

# 日志文件
*.log

# 系统文件
.DS_Store
Thumbs.db

# 编辑器
.vscode/
.idea/
*.swp
*.swo

# 临时文件
tmp/
temp/
```

---

## 📊 发布后验证

### 1. 访问测试

```bash
# 使用 curl 测试
curl -I https://你的用户名.github.io/仓库名/openclaw-intro.html
```

### 2. 链接检查

访问每个页面，确保：
- ✅ 导航栏链接正常
- ✅ 页脚链接正常
- ✅ 页面跳转正确

### 3. 移动端测试

- 在手机上打开网站
- 检查响应式布局
- 测试导航菜单

### 4. SEO 验证

- 检查 `<title>` 和 `<meta description>`
- 使用 [Google Search Console](https://search.google.com/search-console) 提交网站

---

## 🎯 推荐方案

**对于 OpenClaw 介绍网站，推荐使用 GitHub Pages：**

1. ✅ 完全免费
2. ✅ 与你的代码仓库在一起
3. ✅ 更新方便（git push 即可）
4. ✅ 社区熟悉，文档丰富
5. ✅ 适合静态 HTML 网站

---

## 📞 遇到问题？

- GitHub Pages 文档：https://docs.github.com/pages
- Vercel 文档：https://vercel.com/docs
- Netlify 文档：https://docs.netlify.com
- Cloudflare Pages：https://developers.cloudflare.com/pages

---

**最后更新：2026 年 4 月 2 日**
