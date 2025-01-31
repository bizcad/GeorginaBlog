﻿using System;
using LinkDotNet.Blog.Domain;

namespace LinkDotNet.Blog.TestUtilities;

public class BlogPostBuilder
{
    private string title = "BlogPost";
    private string shortDescription = "Some Text";
    private string content = "Some Content";
    private string previewImageUrl = "localhost";
    private string previewImageUrlFallback = null;
    private bool isPublished = true;
    private string[] tags;
    private int likes;
    private DateTime? updateDate;

    public BlogPostBuilder WithTitle(string title)
    {
        this.title = title;
        return this;
    }

    public BlogPostBuilder WithShortDescription(string shortDescription)
    {
        this.shortDescription = shortDescription;
        return this;
    }

    public BlogPostBuilder WithContent(string content)
    {
        this.content = content;
        return this;
    }

    public BlogPostBuilder WithPreviewImageUrl(string url)
    {
        previewImageUrl = url;
        return this;
    }

    public BlogPostBuilder WithPreviewImageUrlFallback(string url)
    {
        previewImageUrlFallback = url;
        return this;
    }

    public BlogPostBuilder WithTags(params string[] tags)
    {
        this.tags = tags;
        return this;
    }

    public BlogPostBuilder IsPublished(bool isPublished = true)
    {
        this.isPublished = isPublished;
        return this;
    }

    public BlogPostBuilder WithLikes(int likes)
    {
        this.likes = likes;
        return this;
    }

    public BlogPostBuilder WithUpdatedDate(DateTime updateDate)
    {
        this.updateDate = updateDate;
        return this;
    }

    public BlogPost Build()
    {
        var blogPost = BlogPost.Create(title, shortDescription, content, previewImageUrl, isPublished, updateDate, tags, previewImageUrlFallback);
        blogPost.Likes = likes;
        return blogPost;
    }
}
