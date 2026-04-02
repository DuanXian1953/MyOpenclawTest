# 发布 OpenClaw 介绍页面到网络并接入 Google AdSense

## 📦 第一部分：发布网站

### 方案 A：GitHub Pages（免费，最简单）⭐

#### 步骤 1：创建 GitHub 仓库

```bash
# 创建工作目录
mkdir openclaw-website
cd openclaw-website

# 初始化 Git
git init

# 复制 HTML 文件
cp C:/Users/Administrator/.openclaw/workspace/openclaw-intro.html index.html

# 创建 .gitignore
echo "_site/" > .gitignore
echo ".DS_Store" >> .gitignore

# 提交
git add .
git commit -m "Initial commit: OpenClaw intro page"
```

#### 步骤 2：推送到 GitHub

```bash
# 在 GitHub 创建新仓库（例如：openclaw-intro）
# 然后关联并推送

git remote add origin https://github.com/你的用户名/openclaw-intro.git
git branch -M main
git push -u origin main
```

#### 步骤 3：启用 GitHub Pages

1. 进入仓库 → **Settings** → **Pages**
2. **Source** 选择 `Deploy from a branch`
3. **Branch** 选择 `main` / 文件夹 `/(root)`
4. 点击 **Save**
5. 等待 1-2 分钟，页面将发布到：
   - `https://你的用户名.github.io/openclaw-intro/`

#### 步骤 4：绑定自定义域名（可选）

1. 在仓库根目录创建 `CNAME` 文件：
   ```
   openclaw.ai
   ```
2. 在你的域名服务商处添加 DNS 记录：
   ```
   类型：CNAME
   名称：@ 或 www
   值：你的用户名.github.io
   ```
3. 在 GitHub Pages 设置中输入自定义域名

---

### 方案 B：Vercel（免费，自动 HTTPS）

#### 步骤 1：安装 Vercel CLI

```bash
npm install -g vercel
```

#### 步骤 2：部署

```bash
cd C:/Users/Administrator/.openclaw/workspace
vercel --prod
```

按提示操作：
- 登录/注册 Vercel 账号
- 确认项目设置
- 获得部署 URL（如：`https://openclaw-intro.vercel.app`）

#### 步骤 3：绑定自定义域名

1. 访问 [vercel.com](https://vercel.com)
2. 进入项目 → **Settings** → **Domains**
3. 添加你的域名
4. 按提示配置 DNS

---

### 方案 C：Netlify（免费，拖拽部署）

#### 步骤 1：直接拖拽部署

1. 访问 [netlify.com](https://netlify.com)
2. 登录/注册
3. 将 `openclaw-intro.html` 所在文件夹拖到部署区域
4. 获得临时 URL

#### 步骤 2：使用 Netlify CLI（可选）

```bash
npm install -g netlify-cli
cd C:/Users/Administrator/.openclaw/workspace
netlify deploy --prod
```

---

### 方案 D：自有服务器（完全控制）

#### 使用 Nginx

```nginx
# /etc/nginx/sites-available/openclaw
server {
    listen 80;
    server_name openclaw.ai www.openclaw.ai;
    
    root /var/www/openclaw;
    index index.html;
    
    location / {
        try_files $uri $uri/ =404;
    }
    
    # Gzip 压缩
    gzip on;
    gzip_types text/plain text/css application/json application/javascript text/xml application/xml;
    
    # 缓存静态资源
    location ~* \.(jpg|jpeg|png|gif|ico|css|js)$ {
        expires 1y;
        add_header Cache-Control "public, immutable";
    }
}
```

```bash
# 部署
sudo mkdir -p /var/www/openclaw
sudo cp openclaw-intro.html /var/www/openclaw/index.html
sudo ln -s /etc/nginx/sites-available/openclaw /etc/nginx/sites-enabled/
sudo nginx -t
sudo systemctl reload nginx
```

#### 使用 Docker

```dockerfile
FROM nginx:alpine
COPY openclaw-intro.html /usr/share/nginx/html/index.html
EXPOSE 80
```

```bash
docker build -t openclaw-website .
docker run -d -p 80:80 --name openclaw-site openclaw-website
```

---

## 📢 第二部分：接入 Google AdSense

### 前提条件

- ✅ 网站已发布并可公开访问
- ✅ 拥有网站所有权验证权限
- ✅ 网站有原创内容（不能是空壳页）
- ✅ 符合 AdSense 政策要求

### 步骤 1：申请 Google AdSense 账号

1. 访问 [https://www.google.com/adsense](https://www.google.com/adsense)
2. 点击 **开始使用**
3. 使用 Google 账号登录
4. 填写网站信息：
   - 网站 URL：`https://openclaw.ai`（或你的 GitHub Pages URL）
   - 语言：中文
   - 国家/地区：中国
5. 阅读并接受条款

### 步骤 2：验证网站所有权

#### 方法 A：HTML 标签验证（推荐）

1. AdSense 后台 → **网站** → **添加网站**
2. 选择 **HTML 标签** 验证方式
3. 复制提供的 meta 标签，如：
   ```html
   <meta name="google-adsense-account" content="ca-pub-XXXXXXXXXXXXXXXX">
   ```
4. 将标签添加到你的 HTML 文件 `<head>` 部分
5. 保存并重新部署网站
6. 回到 AdSense 点击 **验证**

#### 方法 B：HTML 文件验证

1. 下载 AdSense 提供的验证文件（如：`googleXXXXXXXXXXXX.html`）
2. 上传到网站根目录
3. 确保可通过 `https://你的域名/googleXXXXXXXXXXXX.html` 访问
4. 点击验证

### 步骤 3：等待审核

- ⏰ 审核时间：通常 1-3 个工作日，最长 2 周
- 📧 审核结果会通过邮件通知
- ✅ 审核通过后才能显示广告

### 步骤 4：创建广告单元

审核通过后：

1. 登录 AdSense → **广告** → **按广告单元**
2. 选择广告类型：
   - **展示广告**（推荐）：自适应尺寸
   - **信息流广告**：适合内容页
   - **匹配内容广告**：推荐相关内容
3. 设置广告名称（如：`首页顶部横幅`）
4. 选择尺寸（推荐自适应）
5. 点击 **创建**
6. 复制广告代码

### 步骤 5：将广告代码添加到页面

将广告代码粘贴到 HTML 中想要显示广告的位置：

```html
<!-- 顶部横幅广告 -->
<div class="ad-container">
    <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-XXXXXXXXXXXXXXXX"
            crossorigin="anonymous"></script>
    <ins class="adsbygoogle"
         style="display:block"
         data-ad-client="ca-pub-XXXXXXXXXXXXXXXX"
         data-ad-slot="1234567890"
         data-ad-format="auto"
         data-full-width-responsive="true"></ins>
    <script>
         (adsbygoogle = window.adsbygoogle || []).push({});
    </script>
</div>
```

### 步骤 6：优化广告位置

推荐的广告位：

1. **页眉下方** - 曝光率高
2. **内容中间** - 自然插入，不影响体验
3. **侧边栏** - 桌面端效果好
4. **页脚上方** - 浏览完内容后看到

### 步骤 7：设置广告优化

AdSense 后台 → **广告** → **优化**

- ✅ 启用 **自动广告**
- ✅ 设置 **广告加载优化**
- ✅ 配置 **广告平衡**（收入 vs 用户体验）

---

## ⚠️ 重要注意事项

### AdSense 政策合规

1. **原创内容** - 不能复制他人内容
2. **有效点击** - 禁止自己或鼓励他人点击广告
3. **广告位置** - 不能误导用户点击
4. **页面质量** - 内容充实，非空壳页
5. **隐私政策** - 必须有隐私政策页面
6. **联系方式** - 提供有效的联系信息

### 提高审核通过率

1. ✅ 网站至少有 10-20 篇原创内容
2. ✅ 清晰的导航结构
3. ✅ 专业的网站设计
4. ✅ 快速的加载速度
5. ✅ 移动端友好
6. ✅ 有隐私政策、关于我们等页面

### 收入预期

- 新站初期：$0.5 - $5 / 天
- 稳定后：取决于流量和质量
- 中国流量 RPM 约 $1-5
- 美国流量 RPM 约 $5-20

### 提现门槛

- 最低提现：$100
- 支付方式：银行转账、支票、西联汇款
- 付款周期：每月 21-26 日

---

## 🔧 第三部分：完整部署脚本

### 一键部署到 GitHub Pages

```bash
#!/bin/bash
# deploy-to-github.sh

# 配置
REPO_NAME="openclaw-intro"
GITHUB_USER="你的 GitHub 用户名"
HTML_FILE="C:/Users/Administrator/.openclaw/workspace/openclaw-intro.html"

# 创建临时目录
TEMP_DIR=$(mktemp -d)
cd $TEMP_DIR

# 克隆仓库
git clone https://github.com/$GITHUB_USER/$REPO_NAME.git
cd $REPO_NAME

# 复制 HTML 文件
cp $HTML_FILE index.html

# 提交并推送
git add .
git commit -m "Update: $(date '+%Y-%m-%d %H:%M:%S')"
git push origin main

# 清理
cd /
rm -rf $TEMP_DIR

echo "✅ 部署完成！"
echo "🌐 访问：https://$GITHUB_USER.github.io/$REPO_NAME/"
```

### 自动验证 AdSense

```bash
#!/bin/bash
# verify-adsense.sh

# 检查网站是否可访问
URL="https://你的域名.com"
RESPONSE=$(curl -s -o /dev/null -w "%{http_code}" $URL)

if [ "$RESPONSE" == "200" ]; then
    echo "✅ 网站可访问"
else
    echo "❌ 网站不可访问，HTTP 状态码：$RESPONSE"
    exit 1
fi

# 检查 AdSense 标签是否存在
if curl -s $URL | grep -q "google-adsense-account"; then
    echo "✅ AdSense 标签已添加"
else
    echo "❌ AdSense 标签未找到"
    exit 1
fi

echo "✅ 验证通过，可以提交 AdSense 审核"
```

---

## 📊 第四部分：监控与分析

### Google Analytics 集成

```html
<!-- Google tag (gtag.js) -->
<script async src="https://www.googletagmanager.com/gtag/js?id=G-XXXXXXXXXX"></script>
<script>
  window.dataLayer = window.dataLayer || [];
  function gtag(){dataLayer.push(arguments);}
  gtag('js', new Date());
  gtag('config', 'G-XXXXXXXXXX');
</script>
```

### AdSense 性能监控

1. **收入报告** - 每日/每周/每月
2. **页面报告** - 哪些页面收入高
3. **广告格式报告** - 哪种广告效果好
4. **优化建议** - AdSense 自动推荐

### SEO 监控

使用 Google Search Console：
- 索引状态
- 搜索查询
- 点击率
- 移动设备友好度

---

## 🎯 快速检查清单

### 发布前
- [ ] HTML 文件语法正确
- [ ] 所有链接有效
- [ ] 移动端测试通过
- [ ] 加载速度优化
- [ ] SEO meta 标签完整

### AdSense 申请前
- [ ] 网站有 10+ 原创内容
- [ ] 隐私政策页面
- [ ] 联系我们页面
- [ ] 导航清晰
- [ ] 无版权侵权内容

### 上线后
- [ ] 提交 Google Search Console
- [ ] 设置 Google Analytics
- [ ] 监控广告表现
- [ ] 定期更新内容
- [ ] 遵守 AdSense 政策

---

## 💡 进阶技巧

### 1. 广告优化

```javascript
// 延迟加载广告，提升页面速度
window.addEventListener('load', function() {
    setTimeout(function() {
        var ads = document.querySelectorAll('.adsbygoogle');
        ads.forEach(function(ad) {
            (adsbygoogle = window.adsbygoogle || []).push({});
        });
    }, 2000);
});
```

### 2. 广告屏蔽检测

```javascript
// 检测广告屏蔽
setTimeout(function() {
    var ad = document.querySelector('.adsbygoogle');
    if (ad && ad.clientHeight === 0) {
        // 显示提示
        console.log('检测到广告屏蔽，请支持我们');
    }
}, 1000);
```

### 3. A/B 测试广告位置

使用 Google Optimize 测试不同广告位置的收入效果。

---

## 📞 需要帮助？

- **AdSense 帮助中心**: [support.google.com/adsense](https://support.google.com/adsense)
- **GitHub Pages 文档**: [pages.github.com](https://pages.github.com)
- **Vercel 文档**: [vercel.com/docs](https://vercel.com/docs)

---

**祝你发布顺利，广告收入满满！💰**
